import React, { useEffect, useState } from "react";
import ButtonAppBar from "../components/ButtonAppBar";
import { DataGrid, GridColDef, GridValueGetterParams } from "@mui/x-data-grid";

import { BaseListModel } from "../models/BaseListModel";
import { PlayersListItemModel } from "../models/PlayersListItemModel";
import { GRID_RUSSIAN_LOCALE_TEXT } from "../locale/GridLocale";
import { GridPaginationModel } from "@mui/x-data-grid/models/gridPaginationProps";
import { useNavigate } from "react-router-dom";

function Players() {
  const navigate = useNavigate();
  const [pageLoading, setPageLoading] = useState(false);
  const [pageContent, setPageContent] = useState<
    BaseListModel<PlayersListItemModel>
  >(
    new BaseListModel({ items: [], page: 0, pageSize: 13, totalItemsCount: 0 })
  );

  const fetchData = (model: GridPaginationModel) => {
    setPageLoading(true);
    fetch(
      `https://localhost:44331/Players/GetProPlayers?page=${pageContent.page}&pageSize=${pageContent.pageSize}`
    )
      .then((response) => response.json())
      .then((data) => {
        const newPageContent = new BaseListModel<PlayersListItemModel>({
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
      field: "avatarUrl",
      headerName: "",
      width: 75,
      renderCell: (params) => <img src={params.value} width={50} height={50} />,
    },
    {
      field: "name",
      headerName: "Ник",
      type: "string",
      sortable: false,
    },
    {
      field: "teamName",
      headerName: "Команда",
      type: "string",
      sortable: false,
      width: 150,
    },
    {
      field: "role",
      headerName: "Роль",
      type: "string",
      sortable: false,
    },
    {
      field: "region",
      headerName: "Код региона",
      type: "string",
      sortable: false,
    },
    {
      field: "matchesCount",
      headerName: "Число матчей",
      type: "string",
      sortable: false,
      width: 125,
    },
    {
      field: "winsCount",
      headerName: "Число побед",
      type: "string",
      sortable: false,
    },
    {
      field: "lossesCount",
      headerName: "Число поражений",
      type: "string",
      sortable: false,
      width: 150,
    },
    {
      field: "prizes",
      headerName: "Призовые ($)",
      type: "string",
      sortable: false,
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
            onRowClick={(row) => navigate(`/Player/${row.row.id}`)}
          />
        </div>
      </div>
    </div>
  );
}

export default Players;
