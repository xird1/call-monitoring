import { useState } from "react";
import { useAuth } from "../../hooks/useAuth";
import "./LoginPage.css";
import { post } from "../../services/basehttp";

export const LoginPage = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const { authenticate } = useAuth();
  const userCredentials = {
    username: username,
    password: password,
  };

  const handleLogin = async (e) => {
    e.preventDefault();
    if (username === "" || password === "") {
      alert("Please fill both fields");
    } else {
      const userDetails = await post("api/auth/login", userCredentials);
      if (userDetails) {
        await authenticate({ username });
      } else {
        alert("Invalid username or password");
      }
    }
  };

  return (
    <div className={"mainContainer"}>
      <div className={"titleContainer"}>
        <div>Call Monitoring Test Site</div>
      </div>
      <form onSubmit={handleLogin}>
        <div className={"inputContainer"}>
          <label htmlFor="username">Username:</label>
          <input
            id="username"
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            className={"inputBox"}
          />
        </div>
        <div className={"inputContainer"}>
          <label htmlFor="password">Password:</label>
          <input
            id="password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className={"inputBox"}
          />
        </div>
        <br />
        <div className={"inputContainer"}>
          <button className={"inputButton"} type="submit">
            Login
          </button>
        </div>
      </form>
    </div>
  );
};
