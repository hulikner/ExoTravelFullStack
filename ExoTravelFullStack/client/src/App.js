import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import { Spinner } from 'reactstrap';
import ApplicationViews from "./components/ApplicationViews";
import { onLoginStatusChange } from "./modules/AuthManager";
import { Header } from "./components/Header"
import { Footer } from "./components/footer/Footer"
// import { getUserByFirebaseId } from './modules/AuthManager';
// import firebase from "firebase/app";

function App({ getLoggedInUser }) {
  const [isLoggedIn, setIsLoggedIn] = useState(null);

  useEffect(() => {
    onLoginStatusChange(setIsLoggedIn);
  }, []);
  

  if (isLoggedIn === null) {
    return <Spinner className="app-spinner dark" />;
  }

  return (
    <Router>
      <Header isLoggedIn={isLoggedIn}/>
      <ApplicationViews isLoggedIn={isLoggedIn} getLoggedInUser={getLoggedInUser} />
      <Footer />
    </Router>
  );
}

export default App;


