import React, { useState } from 'react';
import { NavLink as RRNavLink, Link, useLocation } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap';
import { logout } from '../modules/AuthManager';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGlobe, faArrowRightFromBracket, faPassport, faShuttleSpace, faUserAstronaut } from "@fortawesome/free-solid-svg-icons";
import './Header.css'

export function Header({ isLoggedIn }) {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);
  const location = useLocation();
  return (
    
      <Navbar color="dark" light expand="md">
        <NavbarBrand tag={RRNavLink} to="/" className="nav-link" activeclassname="active"></NavbarBrand>
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            {isLoggedIn &&
              <nav className="nav-bar">
              <ul className="navBar">
                <div className="nav-logo">
                  <Link className={`navbar__link ${location.pathname === "/home" ? "active" : ""}`} to="/home">
                    {" "}
                    <img height='50px' width='100px' className="nav-logo-home" src="/Images/Exo-Travel-Logo.svg" />{" "}
                  </Link>
                </div>
                <Link className={`navbar__link ${location.pathname === "/exoPlanets" ? "active" : ""}`} to="/exoPlanets">
                  {" "}
                  <FontAwesomeIcon icon={faGlobe} /> Exo-Planets{" "}
                </Link>
                <Link className={`navbar__link ${location.pathname === "/hubDrives" ? "active" : ""}`} to="/hubDrives">
                  {" "}
                  <FontAwesomeIcon icon={faShuttleSpace} /> How It Works{" "}
                </Link>
                <Link className={`navbar__link ${location.pathname === "/abouts" ? "active" : ""}`} to="/abouts">
                  {" "}
                  <FontAwesomeIcon icon={faUserAstronaut} /> About Us{" "}
                </Link>
                <Link className={`navbar__link ${location.pathname === "/logs" ? "active" : ""}`} to="/logs">
                  {" "}
                  <FontAwesomeIcon icon={faPassport} /> Logs{" "}
                </Link>
                
                  <Link className="navbar__link" to="/login" >
                    {" "}
                    <FontAwesomeIcon icon={faArrowRightFromBracket} /> Logout{" "}
                  </Link>
                
              </ul>
            </nav>
            }
            {!isLoggedIn &&
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/register">Register</NavLink>
                </NavItem>
                
              </>
            }
          </Nav>
        </Collapse>
      </Navbar>
      
  );
}
