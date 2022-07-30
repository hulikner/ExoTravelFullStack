import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useNavigate, Link } from "react-router-dom";
import { login } from "../modules/AuthManager";
import "./Login.css";


export function Login() {
  const navigate = useNavigate();

  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const loginSubmit = (e) => {
    e.preventDefault();
    login(email, password)
      .then(() => navigate("/"))
      .catch(() => alert("Invalid email or password"));
  };

  return (
    <Form onSubmit={loginSubmit}>
      <fieldset className="login-container">
      <div className="login-logo-home">
              <img className="login-logo-home" src="/Images/Exo-Travel-Logo.svg" />
            </div>
            <h2 className="sign-in">Sign In</h2>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            id="email"
            type="text"
            autoFocus
            onChange={(e) => setEmail(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input
            id="password"
            type="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </FormGroup>
        <br />
        <FormGroup>
          <Button className="login-btn">Login</Button>
        </FormGroup>
        <em className="login-register">
          Not registered? <Link className="registerLink" to="/register">Register</Link>
        </em>
      </fieldset>
    </Form>
  );
}