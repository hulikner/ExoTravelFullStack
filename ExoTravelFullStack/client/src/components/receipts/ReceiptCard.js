// Imports
import React from "react";
import { Link } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";
import "./ReceiptCard.css";

// Receipt Card
export const ReceiptCard = ({ receipt }) => {
  // Formats dates from epoch time to a readable date
  const formattedDepartureDate = receipt?.departureDate && epochDateConverter(receipt.departureDate, "eee. MMM do");
  const formattedReturnDate = receipt?.returnDate && epochDateConverter(receipt.returnDate, "eee. MMM do");

  // Displays receipt card
  return (
    <Link className="receipt-card-link" to={`/logs/logId/receipts/${receipt.id}`}>
      <div className="receipt-card-content">
        <div className="receipt-card-img">
          <img className="receipt-pic" src={`../../Images/${receipt.exoPlanet.name}.jpg`} />
          <p className="receipt-pic-title">{receipt.exoPlanet.name}</p>
        </div>
        <div className="receipt-card-info">
          <span className="receipt-card">First Name: {receipt.user.firstName}</span>
          <br />
          <span className="receipt-card">Last Name: {receipt.user.lastName}</span>
          <br />
          <span className="receipt-card">Departure Date: {formattedDepartureDate}</span>
          <br />
          <span className="receipt-card">Return Date: {formattedReturnDate}</span>
          <br />
          <span className="receipt-card">Travel Mode: {receipt.mode}</span>
          <br />
        </div>
      </div>
    </Link>
  );
};
