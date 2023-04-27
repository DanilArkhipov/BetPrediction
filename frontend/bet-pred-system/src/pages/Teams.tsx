import React, { useEffect, useState } from "react";
import ButtonAppBar from "../components/ButtonAppBar";
import { BaseListModel } from "../models/BaseListModel";
import { PlayersListItemModel } from "../models/PlayersListItemModel";
import { GridPaginationModel } from "@mui/x-data-grid/models/gridPaginationProps";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { GRID_RUSSIAN_LOCALE_TEXT } from "../locale/GridLocale";
import { TeamsListItemModel } from "../models/TeamsListItemModel";

function Teams() {
  const [pageLoading, setPageLoading] = useState(false);
  const [pageContent, setPageContent] = useState<
    BaseListModel<TeamsListItemModel>
  >(
    new BaseListModel({ items: [], page: 0, pageSize: 13, totalItemsCount: 0 })
  );

  const fetchData = (model: GridPaginationModel) => {
    setPageLoading(true);
    fetch(
      `https://localhost:44331/Teams/GetTeams?page=${pageContent.page}&pageSize=${pageContent.pageSize}`
    )
      .then((response) => response.json())
      .then((data) => {
        const newPageContent = new BaseListModel<TeamsListItemModel>({
          items: data.items,
          page: model.page,
          pageSize: model.pageSize,
          totalItemsCount: data.totalItemsCount,
        });
        setPageContent(newPageContent);
        setPageLoading(false);
      })
      .catch(() => {
        setPageLoading(false);
      });
  };

  useEffect(() => {
    fetchData(pageContent);
  }, []);

  const columns: GridColDef[] = [
    {
      field: "teamLogoUrl",
      headerName: "",
      width: 75,
      renderCell: (params) => <img src={params.value} width={50} height={50} />,
    },
    {
      field: "teamName",
      headerName: "Название",
      type: "string",
      sortable: false,
      flex: 1,
    },
    {
      field: "teamTag",
      headerName: "Тег",
      type: "string",
      sortable: false,
      flex: 1,
    },
    {
      field: "totalWins",
      headerName: "Количество побед",
      type: "string",
      sortable: false,
      flex: 1,
    },
    {
      field: "totalLosses",
      headerName: "Количество поражений",
      type: "string",
      sortable: false,
      flex: 1,
    },
  ];

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
        <div style={{ flex: 1 }}>
          <DataGrid
            rows={pageContent.items}
            columns={columns}
            initialState={{
              pagination: {
                paginationModel: {
                  pageSize: 5,
                },
              },
            }}
            pageSizeOptions={[25]}
            localeText={GRID_RUSSIAN_LOCALE_TEXT}
            loading={pageLoading}
            paginationMode={"server"}
            rowCount={pageContent.totalItemsCount}
            paginationModel={pageContent}
            onPaginationModelChange={fetchData}
          />
        </div>
      </div>
    </div>
  );
}

export default Teams;
