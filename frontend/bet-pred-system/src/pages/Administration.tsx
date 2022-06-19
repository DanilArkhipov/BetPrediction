import React, { useEffect, useState } from "react";
import ButtonAppBar from "../components/ButtonAppBar";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { GRID_RUSSIAN_LOCALE_TEXT } from "../locale/GridLocale";
import { GridPaginationModel } from "@mui/x-data-grid/models/gridPaginationProps";
import { BaseListModel } from "../models/BaseListModel";
import { PlayersListItemModel } from "../models/PlayersListItemModel";
import { useNavigate } from "react-router-dom";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import SelectDateDialog from "../components/SelectDateDialog";

function Administration() {
  const navigate = useNavigate();
  const [pageLoading, setPageLoading] = useState(false);
  const [pageContent, setPageContent] = useState<
    BaseListModel<PlayersListItemModel>
  >(
    new BaseListModel({ items: [], page: 0, pageSize: 13, totalItemsCount: 0 })
  );
  const [loadDataOpen, setLoadDataOpen] = useState(false);
  const [trainClassifiersOpen, setTrainClassifiersOpen] = useState(false);

  const onLoadDataSelectedDate = (startDate: Date, endDate: Date) => {
    fetch(`https://localhost:44331/Administration/LoadDataToSystem`, {
      method: "POST",
      body: JSON.stringify({
        startPeriodDate: startDate,
        endPeriodDate: endDate,
      }),
      credentials: "include",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    }).then((response) =>
      fetchData(
        new BaseListModel({
          items: [],
          page: 0,
          pageSize: 13,
          totalItemsCount: 0,
        })
      )
    );
  };

  const onTrainClassifiersSelectedDate = (startDate: Date, endDate: Date) => {
    fetch(`https://localhost:44331/Administration/TrainClassifiers`, {
      method: "POST",
      body: JSON.stringify({
        startPeriodDate: startDate,
        endPeriodDate: endDate,
      }),
      credentials: "include",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    }).then((response) =>
      fetchData(
        new BaseListModel({
          items: [],
          page: 0,
          pageSize: 13,
          totalItemsCount: 0,
        })
      )
    );
  };

  const fetchData = (model: GridPaginationModel) => {
    setPageLoading(true);
    fetch(
      `https://localhost:44331/Administration/GetLogs?page=${pageContent.page}&pageSize=${pageContent.pageSize}`
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
      field: "id",
      headerName: "Идентификатор",
      flex: 1,
      type: "string",
      headerAlign: "center",
      align: "center",
    },
    {
      field: "userName",
      headerName: "Имя администратора",
      type: "string",
      sortable: false,
      flex: 1,
      headerAlign: "center",
      align: "center",
    },
    {
      field: "startDate",
      headerName: "Дата запуска",
      type: "string",
      sortable: false,
      flex: 1,
      headerAlign: "center",
      align: "center",
    },
    {
      field: "actionName",
      headerName: "Действие",
      type: "string",
      sortable: false,
      flex: 1,
      headerAlign: "center",
      align: "center",
    },
    {
      field: "period",
      headerName: "Период",
      type: "string",
      sortable: false,
      flex: 1,
      headerAlign: "center",
      align: "center",
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
          height: "56px",
          flexDirection: "row",
          justifyContent: "start",
          margin: "72px 300px 0px 300px",
          alignItems: "center",
        }}
      >
        <Button
          variant={"outlined"}
          style={{ marginRight: "15px" }}
          onClick={() => {
            setLoadDataOpen(true);
          }}
        >
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Загрузить данные
          </Typography>
        </Button>
        <Button
          variant={"outlined"}
          onClick={() => setTrainClassifiersOpen(true)}
        >
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Обучить классификаторы
          </Typography>
        </Button>
      </div>
      <div
        style={{
          margin: "0px 300px 0px 300px",
          height: "calc(100vh - 128px)",
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
      <SelectDateDialog
        onSelected={onLoadDataSelectedDate}
        showDialog={loadDataOpen}
        close={() => setLoadDataOpen(false)}
      ></SelectDateDialog>
      <SelectDateDialog
        onSelected={onTrainClassifiersSelectedDate}
        showDialog={trainClassifiersOpen}
        close={() => setTrainClassifiersOpen(false)}
      ></SelectDateDialog>
    </div>
  );
}

export default Administration;
