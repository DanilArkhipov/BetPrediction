import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import { useNavigate } from "react-router-dom";

export default function ButtonAppBar() {
  const navigate = useNavigate();
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
          </div>
          <Button color="inherit" onClick={() => navigate("/Administration")}>
            <img
              src={
                "https://img.icons8.com/material-outlined/256/settings--v3.png"
              }
              height={"32px"}
            />
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
