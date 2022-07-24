import React from "react"
import { Routes, Route, Navigate } from "react-router-dom"
import { Login } from "./Login"
import { Register } from "./Register"
import { Home } from "./Home"
import { ExoPlanetDetail } from "./exoPlanets/ExoPlanetDetail"
import { ExoPlanetList } from "./exoPlanets/ExoPlanetList"
import { LogList } from "./logs/LogList"
import { LogDetail } from "./logs/LogDetail"
import { LogEditForm } from "./logs/LogEditForm"
import { HubDriveList } from "./hubDrives/HubDriveList"
import { HubDriveDetail } from "./hubDrives/HubDriveDetail"
import { AboutList } from "./abouts/AboutList"
import { AboutDetail } from "./abouts/AboutDetail"
import { ReviewList } from "./reviews/ReviewList"
import { ReviewForm } from "./reviews/ReviewForm"
import { ReviewEditForm } from "./reviews/ReviewEditForm"
import { ReceiptList } from "./receipts/ReceiptList"
import { ReceiptDetail } from "./receipts/ReceiptDetail"


export default function ApplicationViews({ isLoggedIn, getLoggedInUser }) {
    return (
      <>
      <Routes>
      <Route path="/">
          <Route
            index
            element={isLoggedIn ? <Home /> : <Navigate to="/login" />}
          />
          <Route path="login" element={<Login />} />
          <Route path="register" element={<Register />} />
          <Route path="/home" element={<Home isLoggedIn={isLoggedIn} getLoggedInUser={getLoggedInUser} />} />
          <Route path="/exoPlanets" element={<ExoPlanetList />} />
          <Route path="/exoPlanets/:exoPlanetId" element={<ExoPlanetDetail />} />
          <Route path="/exoPlanets/:exoPlanetId/reviews" element={<ReviewList />} />
          <Route path="/exoPlanets/:exoPlanetId/reviews/create" element={<ReviewForm />} />
          <Route path="/exoPlanets/:exoPlanetId/reviews/:reviewId/edit" element={<ReviewEditForm />} />
          <Route path="/hubDrives" element={<HubDriveList />} />
          <Route path="/hubDrives/:hubDriveId" element={<HubDriveDetail />} />
          <Route path="/abouts" element={<AboutList />} />
          <Route path="/abouts/:aboutId" element={<AboutDetail />} />
          <Route path="/logs" element={<LogList />} /> 
          <Route path="/logs/:logId" element={<LogDetail />} />
          <Route path="/logs/:logId/edit" element={<LogEditForm />} />
          <Route path="/logs/:logId/receipts" element={<ReceiptList />} />
          <Route path="/logs/:logId/receipts/:receiptId" element={<ReceiptDetail />} /> 
        </Route>
        
      </Routes>
      </>
    )
  }
