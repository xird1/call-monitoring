import React from "react";
import { Route, Routes } from "react-router-dom";

import "./custom.css";
import { LoginPage } from "./pages/Login/LoginPage";
import { QueueGroupPage } from "./pages/QueueGroup/QueueGroupPage";
import NotFoundPage from "./pages/NotFoundPage";

import { ProtectedRoute } from "./components/protectedRoute";
import { AuthProvider } from "./hooks/useAuth";

function App() {
  return (
    <AuthProvider>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route
          path="/data"
          element={
            <ProtectedRoute>
              <QueueGroupPage />
            </ProtectedRoute>
          }
        />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </AuthProvider>
  );
}

export default App;
