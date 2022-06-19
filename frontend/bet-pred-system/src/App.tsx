import React from "react";
import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Teams from "./pages/Teams";
import Players from "./pages/Players";
import Player from "./pages/Player";
import Administration from "./pages/Administration";
import Login from "./pages/Login";
import Registration from "./pages/Registration";
import Prediction from "./pages/Prediction";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Players />} />
        <Route path="Teams" element={<Teams />} />
        <Route path="Players" element={<Players />} />
        <Route path="Player/:id" element={<Player />} />
        <Route path="Prediction" element={<Prediction />} />
        <Route path="Administration" element={<Administration />} />
        <Route path="Login" element={<Login />} />
        <Route path="Registration" element={<Registration />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
