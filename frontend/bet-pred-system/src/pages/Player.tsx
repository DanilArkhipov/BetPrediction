import React, { useEffect, useState } from "react";
import ButtonAppBar from "../components/ButtonAppBar";

import { useParams } from "react-router-dom";
import { PlayerModel } from "../models/PlayerModel";
import { HeroWinRateModel } from "../models/HeroWinRateModel";
import { Box, Grid } from "@mui/material";
import Typography from "@mui/material/Typography";
import { GRID_RUSSIAN_LOCALE_TEXT } from "../locale/GridLocale";
import { DataGrid, GridColDef } from "@mui/x-data-grid";

function Player() {
  const [pageLoading, setPageLoading] = useState(false);
  const id = useParams();
  const [pageContent, setPageContent] = useState<PlayerModel>();
  const columns: GridColDef[] = [
    {
      field: "heroIconUrl",
      headerName: "",
      width: 75,
      renderCell: (params) => <img src={params.value} width={50} height={50} />,
    },
    {
      field: "name",
      headerName: "Имя",
      type: "string",
      sortable: false,
      flex: 1,
    },
    {
      field: "gamesCount",
      headerName: "Число игр",
      type: "string",
      sortable: false,
      flex: 1,
    },
    {
      field: "winRate",
      headerName: "Процент побед",
      type: "string",
      sortable: false,
      flex: 1,
    },
  ];
  const heroes = [
    new HeroWinRateModel({
      id: "1",
      name: "Terrorblade",
      winRate: 51.3,
      heroIconUrl:
        "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/terrorblade.png?",
      gamesCount: "104",
    }),
    new HeroWinRateModel({
      id: "2",
      name: "Phantom Assassin",
      winRate: 49.1,
      heroIconUrl:
        "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_assassin.png?",
      gamesCount: "93",
    }),
    new HeroWinRateModel({
      id: "3",
      name: "Marci",
      winRate: 48.3,
      heroIconUrl:
        "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/marci.png?",
      gamesCount: "64",
    }),
  ];
  const newPageContent = new PlayerModel({
    id: "B590C05D-0008-4EB2-7EE9-08DB45B1CD58",
    name: "TZY",
    avatarUrl: "https://dota2.ru/img/esport/player/4353.png?1674467887",
    teamName: "iG.Vitality",
    role: "Основа",
    region: "Китай",
    matchesCount: 823,
    winRate: 51.3,
    streak: 2,
    avgKills: 11.2,
    avgDeths: 4.1,
    avgAssists: 7.3,
    avgPlacedObserverWards: 0.8,
    avgDestroyedObserverWards: 1.3,
    avgPlacedSentryWards: 1.1,
    avgDestroyedSentryWards: 1.4,
    avgCreepsKilled: 453.2,
    avgDenies: 23.1,
    expPerMinute: 632.1,
    goldPerMinute: 723.4,

    heroesWithWinRate: heroes,
  });

  const fetchData = () => {
    setPageLoading(true);
    setPageContent(newPageContent);
    // fetch(`https://localhost:44331/Players/{id}`)
    //   .then((response) => response.json())
    //   .then((data) => {
    //     setPageContent(newPageContent);
    //     setPageLoading(false);
    //   });
    setPageLoading(true);
  };

  useEffect(() => {
    fetchData();
  }, []);

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
          margin: "0px 400px",
        }}
      >
        <Typography style={{ margin: "120px 0 10px 0" }} variant={"h5"}>
          Общая информация
        </Typography>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <img
              src={pageContent?.avatarUrl}
              width={300}
              height={300}
              alt={""}
            />
            ,
          </Grid>
          <Grid item xs={6}>
            <Box>
              <Grid style={{ padding: "20px 0 5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Ник:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>{pageContent?.name}</Typography>
                </Grid>
              </Grid>
              <Grid style={{ padding: "5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Команда:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>
                    {pageContent?.teamName}
                  </Typography>
                </Grid>
              </Grid>
              <Grid style={{ padding: "5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Роль:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>{pageContent?.role}</Typography>
                </Grid>
              </Grid>
              <Grid style={{ padding: "5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Регион:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>{pageContent?.region}</Typography>
                </Grid>
              </Grid>
              <Grid style={{ padding: "5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Число матчей:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>
                    {pageContent?.matchesCount}
                  </Typography>
                </Grid>
              </Grid>
              <Grid style={{ padding: "5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Процент побед:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>
                    {pageContent?.winRate}%
                  </Typography>
                </Grid>
              </Grid>
              <Grid style={{ padding: "5px 0" }} container spacing={2}>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>Серия побед:</Typography>
                </Grid>
                <Grid item xs={6}>
                  <Typography variant={"h6"}>{pageContent?.streak}</Typography>
                </Grid>
              </Grid>
            </Box>
          </Grid>
        </Grid>
        <Typography style={{ padding: "60px 0 10px 0" }} variant={"h5"}>
          Средние показатели за игру
        </Typography>
        <AverageGameIndications
          leftTitle={"Убийства"}
          leftData={pageContent?.avgKills.toString()}
          rightTitle={"Смерти"}
          rightData={pageContent?.avgDeths.toString()}
        ></AverageGameIndications>
        <AverageGameIndications
          leftTitle={"Помощи"}
          leftData={pageContent?.avgAssists.toString()}
          rightTitle={"Убито крипов"}
          rightData={pageContent?.avgCreepsKilled.toString()}
        ></AverageGameIndications>
        <AverageGameIndications
          leftTitle={"Установленно обсерверов"}
          leftData={pageContent?.avgPlacedObserverWards.toString()}
          rightTitle={"Уничтожено обсерверов"}
          rightData={pageContent?.avgDestroyedObserverWards.toString()}
        ></AverageGameIndications>
        <AverageGameIndications
          leftTitle={"Установленно сентри"}
          leftData={pageContent?.avgPlacedSentryWards.toString()}
          rightTitle={"Уничтожено сентри"}
          rightData={pageContent?.avgDestroyedSentryWards.toString()}
        ></AverageGameIndications>
        <AverageGameIndications
          leftTitle={"Золото в минуту"}
          leftData={pageContent?.goldPerMinute.toString()}
          rightTitle={"Опыт в минуту"}
          rightData={pageContent?.expPerMinute.toString()}
        ></AverageGameIndications>
        <AverageGameIndications
          leftTitle={"Не отадано крипов"}
          leftData={pageContent?.avgDenies.toString()}
          rightTitle={""}
          rightData={""}
        ></AverageGameIndications>
        <Typography style={{ padding: "60px 0 10px 0" }} variant={"h5"}>
          Лучшие герои
        </Typography>
        <DataGrid
          style={{ marginBottom: "60px" }}
          rows={pageContent?.heroesWithWinRate ?? []}
          columns={columns}
          pageSizeOptions={[25]}
          localeText={GRID_RUSSIAN_LOCALE_TEXT}
          hideFooter={true}
        />
      </div>
    </div>
  );
}

const AverageGameIndications = (data: {
  leftTitle: string;
  leftData?: string;
  rightTitle?: string;
  rightData?: string;
}) => {
  return (
    <Grid style={{ padding: "5px 0" }} container spacing={2}>
      <Grid item xs={6}>
        <Grid style={{ padding: "5px 0" }} container spacing={2}>
          <Grid item xs={6}>
            <Typography variant={"h6"}>{data.leftTitle}:</Typography>
          </Grid>
          <Grid item xs={6}>
            <Typography variant={"h6"}>{data.leftData}</Typography>
          </Grid>
        </Grid>
      </Grid>
      <Grid item xs={6}>
        <Grid style={{ padding: "5px 0" }} container spacing={2}>
          <Grid item xs={6}>
            <Typography variant={"h6"}>
              {data.rightTitle}
              {!data.rightTitle ? "" : ":"}
            </Typography>
          </Grid>
          <Grid item xs={6}>
            <Typography variant={"h6"}>{data.rightData}</Typography>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default Player;
