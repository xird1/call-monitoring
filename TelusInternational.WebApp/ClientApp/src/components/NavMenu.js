import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";
import { useAuth } from "../hooks/useAuth";

export const NavMenu = () => {
  const [collapsed, setCollapsed] = useState(true);
  const { logout } = useAuth();
  var user = window.localStorage.getItem("user");

  if (user) {
    user = JSON.parse(user);
  }

  const toggleNavbar = function () {
    setCollapsed(!collapsed);
  };

  const handleLogout = () => {
    logout();
  };

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        container
        light
      >
        <NavbarBrand tag={Link} to="/data">
          TestProject
        </NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
        <Collapse
          className="d-sm-inline-flex flex-sm-row-reverse"
          isOpen={!collapsed}
          navbar
        >
          <ul className="navbar-nav flex-grow">
            <NavItem>
              <div>
                <span className="username">Hi, {user.username}</span>
              </div>
            </NavItem>
            <NavItem>
              <div>
                <span onClick={handleLogout} className="logoff">
                  Logoff
                </span>
              </div>
            </NavItem>
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
};
