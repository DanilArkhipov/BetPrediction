import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import { useNavigate } from "react-router-dom";
import SettingsIcon from "@mui/icons-material/Settings";
import LoginIcon from "@mui/icons-material/Login";
import { Logout } from "@mui/icons-material";
import Cookies from "js-cookie";

export default function ButtonAppBar() {
  const navigate = useNavigate();
  const role = Cookies.get("Role");
  return (
    <Box>
      <AppBar>
        <Toolbar className={"header"}>
          <div>
            <Button color="inherit" onClick={() => navigate("/Players")}>
              <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                Игроки
              </Typography>
            </Button>
            <Button color="inherit" onClick={() => navigate("/Teams")}>
              <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                Команды
              </Typography>
            </Button>
            {role ? (
              <Button color="inherit" onClick={() => navigate("/Prediction")}>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                  Прогнозирование
                </Typography>
              </Button>
            ) : (
              <div></div>
            )}
          </div>
          <div style={{ flexDirection: "row", display: "flex" }}>
            {role == "admin" ? (
              <Button
                color="inherit"
                onClick={() => navigate("/Administration")}
              >
                <SettingsIcon />
              </Button>
            ) : (
              <div></div>
            )}
            {!role ? (
              <Button color="inherit" onClick={() => navigate("/Login")}>
                <LoginIcon />
              </Button>
            ) : (
              <div></div>
            )}
            {role ? (
              <Button
                color="inherit"
                onClick={() => {
                  Cookies.remove("Role");
                  navigate("/");
                }}
              >
                <Logout />
              </Button>
            ) : (
              <div></div>
            )}
          </div>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
