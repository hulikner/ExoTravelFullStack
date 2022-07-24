// Imports
import React, { useEffect, useState } from "react";
import { ReceiptCard } from "./ReceiptCard";
import { useParams } from "react-router-dom";
import { getAllReceipts, deleteReceipt, getReceiptByLogId } from "../../modules/ReceiptManager";
import "./ReceiptList.css";

// Receipts list
export const ReceiptList = () => {
  // State setState
  const [receipts, setReceipts] = useState([]);

  // React-Router-DOM use
  const { logId } = useParams();

  // Handles delete
  const handleDeleteReceipt = (id) => {
    deleteReceipt(id).then(() => getAllReceipts().then(setReceipts));
  };

  // Gets receipt by log id and sets
  useEffect(() => {
    getReceiptByLogId(logId).then(setReceipts);
  }, []);

  // Displays receipts
  return (
    <div className="receipt-container">
        <h2 className="receipt-list-header">Receipt</h2>
      <div className="receipt-list">
        <div className="receipt-list-content">
          {receipts.map((i) => (
            <ReceiptCard key={i.id} receipt={i} handleDeleteReceipt={handleDeleteReceipt} />
          ))}
        </div>
      </div>
    </div>
  );
};
