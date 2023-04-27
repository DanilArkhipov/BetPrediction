import React, { useState } from "react";
import ButtonAppBar from "../components/ButtonAppBar";
import { DataGrid } from "@mui/x-data-grid";
import { GRID_RUSSIAN_LOCALE_TEXT } from "../locale/GridLocale";
import { Button, CircularProgress } from "@mui/material";
import { GridPaginationModel } from "@mui/x-data-grid/models/gridPaginationProps";
import { BaseListModel } from "../models/BaseListModel";
import { PlayersListItemModel } from "../models/PlayersListItemModel";

function Administration() {
  const [pageLoading, setPageLoading] = useState(false);

  const fetchData = () => {
    setPageLoading(true);
    fetch(`https://localhost:44331/Administration/LoadDataToSystem`, {
      method: "POST",
    })
      .then((data) => {
        setPageLoading(false);
      })
      .catch(() => {
        setPageLoading(false);
      });
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
      }}
    >
      <ButtonAppBar></ButtonAppBar>
      <div
        style={{
          margin: "64px 300px 0px 300px",
          height: "calc(100vh - 64px)",
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
        }}
      >
        {pageLoading ? (
          <div style={{ placeSelf: "center" }}>
            <CircularProgress></CircularProgress>
          </div>
        ) : (
          <div style={{ placeSelf: "center" }}>
            <Button variant="contained" onClick={fetchData}>
              Загрузить данные в систему
            </Button>
          </div>
        )}
      </div>
    </div>
  );
}

export default Administration;
