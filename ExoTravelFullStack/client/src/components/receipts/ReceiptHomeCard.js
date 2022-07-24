// Imports
import React from "react";
import { Link } from "react-router-dom";
import { epochDateConverter } from "../util/epochDateConverter";


// Receipt home card
export const ReceiptHomeCard = ({ receipt }) => {
  // Formats dates from epoch time to a readable date
  const formattedDepartureDate = receipt?.departureDate && epochDateConverter(receipt.departureDate, "MM/dd/yy");
  const formattedReturnDate = receipt?.returnDate && epochDateConverter(receipt.returnDate, "MM/dd/yy");

  // Displays receipt home
  return (
    <Link className="receipt-home-link" to={`/logs/logId/receipts/${receipt.id}`}>
      <div className="receipt-home-content">
        <div className="receipt-home-img">
          <img className="receipt-home-pic" src={`../../Images/${receipt.exoPlanet.name}.jpg`} />
          <p className="receipt-pic-home-title">{receipt.exoPlanet.name}</p>
        </div>
        <div className="receipt-home-info">
        
          <span className="receipt-home">Departure {formattedDepartureDate}</span>
          <br />
          <span className="receipt-home">Return {formattedReturnDate}</span>
          <br />
          
        </div>
      </div>
    </Link>
  );
};
