// Imports
import React, { useState, useEffect } from "react";
import { getLogById, deleteLog, updateLog } from "../../modules/LogManager";
import { useParams, useNavigate, Link } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBitcoin } from "@fortawesome/free-brands-svg-icons";
import { addReceipt, getReceiptByLogId } from "../../modules/ReceiptManager";
import { ReviewForm } from "../reviews/ReviewForm";
import "./LogDetail.css";

export const LogDetail = () => {
	// Variables to be used
	let finalPrice = 0;
	let selectedVal = 0;
	let tripDuration = 0;

	// React-Router-DOM uses
	const navigate = useNavigate();
	const { logId } = useParams();

	// Gets current day
	const today = new Date().getTime() / 1000;

	// States and setStates
	const [isLoading, setIsLoading] = useState(true);
  const [receipt, setReceipt] = useState([])
	const [log, setLog] = useState({
		userProfileId: "",
		departureDate: "",
		returnDate: "",
		exoPlanetId: "",
		mode: "",
	});

	// Formats epoch dates to a readable date
	const formattedDepartureDate = log?.departureDate && epochDateConverter(log.departureDate, "MM/dd/yyy");
	const formattedReturnDate = log?.returnDate && epochDateConverter(log.returnDate, "MM/dd/yyy");

	// When Pay Now is clicked it adds a receipt and updates the log to paid then goes to receipts page
	const handleClickSaveEvent = async (i) => {
		i.preventDefault();
		const receipt = {
			userProfileId: log.userProfileId,
			departureDate: log.departureDate,
			returnDate: log.returnDate,
			exoPlanetId: log.exoPlanetId,
			mode: log.mode,
			paid: Math.round(finalPrice),
			logId: log.id,
		};

		const newLog = {
			id: +logId,
			userProfileId: log.userProfileId,
			departureDate: log.departureDate,
			returnDate: log.returnDate,
			exoPlanetId: log.exoPlanetId,
			reviewId: log.reviewId,
			mode: log.mode,
		};

		setIsLoading(true);

		// Awaits for addReceipt to finish before updating log
		await addReceipt(receipt);

		// Awaits for updatelog before going to receipts page
		await updateLog({ ...newLog });

		// Navigates to receipts page
		navigate(`/logs/${logId}/receipts`);
	};

	// Calculates cost of travel from The Citidel to Exo-Planet chosen based on mode of travel the user selected
	const drivePlanetCost = (m) => {
		if (m === "Ion-Drive") {
			selectedVal = 0.25;
		}
		if (m === "Warp-Drive") {
			selectedVal = 0.5;
		}
		if (m === "Wormhole-Drive") {
			selectedVal = 2;
		}
		return (selectedVal = selectedVal * log.exoPlanet?.lightYears);
	};

	// Calculates duration of travel from The Citidel to Exo-Planet chosen based on mode of travel the user selected
	const drivePlanetDuration = (m) => {
		if (m === "Ion-Drive") {
			tripDuration = log.exoPlanet?.lightYears / 10;
		}
		if (m === "Warp-Drive") {
			tripDuration = log.exoPlanet?.lightYears / 50;
		}
		if (m === "Wormhole-Drive") {
			tripDuration = 2;
		}
		return tripDuration;
	};

	// Deletes log when button is clicked
	const handleDelete = (logId) => {
		setIsLoading(true);
		deleteLog(logId).then(() => navigate("/logs"));
	};

	// Gets the log clicked on and sets it
	useEffect(() => {
		getLogById(logId).then(setLog);
    getReceiptByLogId(logId).then(setReceipt);
	}, [logId]);

	// Calls the functions to calculate cost and time based on users selections
	drivePlanetCost(log.mode);
	drivePlanetDuration(log.mode);
	finalPrice = selectedVal + 15;
	
	console.log(receipt);
	// log details and buttons to DOM
	return (
		<>
			{" "}
			<div className="log-details-title-container">
				<h2 className="log-details-title">
					{log.userProfile?.firstName}, Here Are The Details On Your Trip To {log.exoPlanet?.name}
				</h2>
			</div>
			<div className="log-detail-image">
				<div className="log-detail-img">
					<img className="log-img" src={`../Images/${log.exoPlanet?.name}.jpg`} />
					<span className="log-img-name">{log.exoPlanet?.name}</span>
				</div>
				<div className="log-detail-summary">
					<div className="log-price-summary">
						<span className="log-detail-title">Price Summary</span>
						<br />
						<span className="log-detail">
							Transport to The Citadel:{" "}
							<span className="log-detail-data">
								<FontAwesomeIcon icon={faBitcoin} />
								10
							</span>
						</span>
						<br />
						<span className="log-detail">
							{log.mode} to {log.exoPlanet?.name}:{" "}
							<span className="log-detail-data">
								<FontAwesomeIcon icon={faBitcoin} /> {selectedVal}{" "}
							</span>
						</span>
						<br />
						<span className="log-detail">
							Exo-Travel Fees:{" "}
							<span className="log-detail-data">
								<FontAwesomeIcon icon={faBitcoin} /> 5
							</span>
						</span>
						<br />
						<span className="log-detail-total">
							Total:{" "}
							<span className="log-detail-data">
								<FontAwesomeIcon icon={faBitcoin} /> {finalPrice}
							</span>
						</span>
						<br />
						<div className="log-price-summary-buttons">
							<button type="button" className="log-price-summary-button" onClick={() => navigate(`/logs/${log.id}/edit`)}>
								Edit
							</button>
							<button type="button" className="log-price-summary-button" onClick={() => handleDelete(logId)}>
								Delete
							</button>
							{receipt.log !== undefined ? (
								<button type="button" className="log-price-summary-button" onClick={() => navigate(`/logs/${log.id}/receipts`)}>
                Receipt
              </button>
							) : (
                <button type="button" className="log-price-summary-button" onClick={handleClickSaveEvent}>
									Pay Now
								</button>
								
							)}
						</div>
					</div>
				</div>
			</div>
			<div className="log-departureDate-returnDate">
				<div className="log-departureDateToreturnDate">
					<span className="log-detail">Departure: {formattedDepartureDate} @ 8:00 AM to The Citadel</span>
					<br />
					<span className="log-detail">Gate Number: 2C </span>
					<br />
					<span className="log-detail">Shuttle Number: {log.departureDate}</span>
					<br />
					<span className="log-detail">Flight Duration: 2 Hours</span>
					<br />
				</div>
				<div className="log-departureDateToreturnDate">
					<span className="log-detail">
						Departure: {formattedDepartureDate} @ 12:00 PM to {log.exoPlanetId?.name}
					</span>
					<br />
					<span className="log-detail">Gate Number: X-4 </span>
					<br />
					<span className="log-detail">Shuttle Number: R2-D2</span>
					<br />
					<span className="log-detail">Flight Duration: {tripDuration} Hours</span>
					<br />
				</div>
				<div className="log-departureDateToreturnDate">
					<span className="log-detail">Return: {formattedReturnDate} @ 8:00 AM to The Citadel</span>
					<br />
					<span className="log-detail">Gate Number: X-4 </span>
					<br />
					<span className="log-detail">Shuttle Number: R2-D2</span>
					<br />
					<span className="log-detail">Flight Duration: {tripDuration} Hours</span>
					<br />
				</div>
				<div className="log-departureDateToreturnDate">
					<span className="log-detail">Return: {formattedDepartureDate} @ 8:00 AM to Origin</span>
					<br />
					<span className="log-detail">Gate Number: 2C </span>
					<br />
					<span className="log-detail">Shuttle Number: {log.returnDate}</span>
					<br />
					<span className="log-detail">Flight Duration: 2 Hours</span>
					<br />
				</div>
			</div>
			<div className="log-page-buttons">
				{log.returnDate < today ? (
					<Link to={`/exoPlanets/${log.exoPlanetId}/reviews/create`}>
						<button type="button" className="log-page-button" onClick={() => navigate(<ReviewForm log={log} />)}>
							Review
						</button>
					</Link>
				) : (
					<span></span>
				)}
				<button type="button" className="log-page-button" onClick={() => navigate(`/logs`)}>
					Back
				</button>
			</div>
			<div className="log-page-bottom"></div>
		</>
	);
};
