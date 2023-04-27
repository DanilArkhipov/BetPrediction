import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Teams from "./pages/Teams";
import Players from "./pages/Players";
import Main from "./pages/Main";
import Player from "./pages/Player";
import Administration from "./pages/Administration";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Players />} />
        <Route path="Teams" element={<Teams />} />
        <Route path="Players" element={<Players />} />
        <Route path="Player/:id" element={<Player />} />
        <Route path="Administration" element={<Administration />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
