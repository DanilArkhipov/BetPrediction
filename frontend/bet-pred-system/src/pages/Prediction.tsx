import React, { useEffect, useState } from "react";
import { PlayerPredictionModel } from "../models/PlayerPredictionDataModel";
import { HeroPredictionModel } from "../models/HeroPredictionModel";
import Typography from "@mui/material/Typography";
import ButtonAppBar from "../components/ButtonAppBar";
import Autocomplete from "@mui/material/Autocomplete";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";

let players: Array<PlayerPredictionModel>;

let heroes: Array<HeroPredictionModel>;

function Prediction() {
  const [pageLoading, setPageLoading] = useState(false);
  const [radiantPlayer1, setRadiantPlayer1] =
    useState<PlayerPredictionModel | null>();
  const [radiantPlayer2, setRadiantPlayer2] =
    useState<PlayerPredictionModel | null>();
  const [radiantPlayer3, setRadiantPlayer3] =
    useState<PlayerPredictionModel | null>();
  const [radiantPlayer4, setRadiantPlayer4] =
    useState<PlayerPredictionModel | null>();
  const [radiantPlayer5, setRadiantPlayer5] =
    useState<PlayerPredictionModel | null>();
  const [radiantHero1, setRadiantHero1] =
    useState<HeroPredictionModel | null>();
  const [radiantHero2, setRadiantHero2] =
    useState<HeroPredictionModel | null>();
  const [radiantHero3, setRadiantHero3] =
    useState<HeroPredictionModel | null>();
  const [radiantHero4, setRadiantHero4] =
    useState<HeroPredictionModel | null>();
  const [radiantHero5, setRadiantHero5] =
    useState<HeroPredictionModel | null>();

  const [direPlayer1, setDirePlayer1] =
    useState<PlayerPredictionModel | null>();
  const [direPlayer2, setDirePlayer2] =
    useState<PlayerPredictionModel | null>();
  const [direPlayer3, setDirePlayer3] =
    useState<PlayerPredictionModel | null>();
  const [direPlayer4, setDirePlayer4] =
    useState<PlayerPredictionModel | null>();
  const [direPlayer5, setDirePlayer5] =
    useState<PlayerPredictionModel | null>();
  const [direHero1, setDireHero1] = useState<HeroPredictionModel | null>();
  const [direHero2, setDireHero2] = useState<HeroPredictionModel | null>();
  const [direHero3, setDireHero3] = useState<HeroPredictionModel | null>();
  const [direHero4, setDireHero4] = useState<HeroPredictionModel | null>();
  const [direHero5, setDireHero5] = useState<HeroPredictionModel | null>();

  const [prediction, setPrediction] = useState<Array<number> | null>();

  const fetchData = () => {
    setPageLoading(true);
    fetch(`https://localhost:44331/Prediction/GetData`)
      .then((response) => response.json())
      .then((data) => {
        players = data.players;
        heroes = data.heroes;
        setPageLoading(false);
      })
      .catch(() => {
        setPageLoading(false);
      });
  };

  const predict = () => {
    fetch(`https://localhost:44331/Prediction/Predict`, {
      method: "POST",
      body: JSON.stringify({
        radiantPlayers: [
          radiantPlayer1?.id,
          radiantPlayer2?.id,
          radiantPlayer3?.id,
          radiantPlayer4?.id,
          radiantPlayer5?.id,
        ],
        radiantHeroes: [
          radiantHero1?.id,
          radiantHero2?.id,
          radiantHero3?.id,
          radiantHero4?.id,
          radiantHero5?.id,
        ],
        direPlayers: [
          direPlayer1?.id,
          direPlayer2?.id,
          direPlayer3?.id,
          direPlayer4?.id,
          direPlayer5?.id,
        ],
        direHeroes: [
          direHero1?.id,
          direHero2?.id,
          direHero3?.id,
          direHero4?.id,
          direHero5?.id,
        ],
      }),
      credentials: "include",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((data) => {
        setPrediction([0, 1]);
        console.log(prediction);
        setPageLoading(false);
      })
      .catch(() => {
        setPageLoading(false);
      });
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
          margin: "100px 350px 0px 350px",
          height: "calc(100vh - 64px)",
          flexDirection: "column",
          justifyContent: "center",
        }}
      >
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          Команда сил света:
        </Typography>
        <div
          style={{
            flexDirection: "row",
            display: "flex",
            justifyContent: "flex-start",
          }}
        >
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {radiantPlayer1 ? (
                <img src={radiantPlayer1.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 1
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantPlayer1 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setRadiantPlayer1(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantHero1 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setRadiantHero1(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {radiantPlayer2 ? (
                <img src={radiantPlayer2.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 2
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantPlayer2 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setRadiantPlayer2(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantHero2 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setRadiantHero2(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {radiantPlayer3 ? (
                <img src={radiantPlayer3.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 3
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantPlayer3 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setRadiantPlayer3(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantHero3 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setRadiantHero3(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {radiantPlayer4 ? (
                <img src={radiantPlayer4.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 4
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantPlayer4 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setRadiantPlayer4(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantHero4 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setRadiantHero4(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {radiantPlayer5 ? (
                <img src={radiantPlayer5.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 5
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantPlayer5 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setRadiantPlayer5(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={radiantHero5 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setRadiantHero5(value)}
            />
          </div>
        </div>
        <Typography
          style={{ marginTop: "60px" }}
          variant="h6"
          component="div"
          sx={{ flexGrow: 1 }}
        >
          Команда сил тьмы:
        </Typography>
        <div
          style={{
            flexDirection: "row",
            display: "flex",
            justifyContent: "flex-start",
          }}
        >
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {direPlayer1 ? (
                <img src={direPlayer1.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 1
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direPlayer1 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setDirePlayer1(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direHero1 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setDireHero1(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {direPlayer2 ? (
                <img src={direPlayer2.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 2
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direPlayer2 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setDirePlayer2(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direHero2 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setDireHero2(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {direPlayer3 ? (
                <img src={direPlayer3.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 3
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direPlayer3 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setDirePlayer3(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direHero3 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setDireHero3(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {direPlayer4 ? (
                <img src={direPlayer4.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 4
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direPlayer4 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setDirePlayer4(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direHero4 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setDireHero4(value)}
            />
          </div>
          <div
            style={{
              margin: "10px 5px 0 0 ",
              height: 240,
              width: 200,
              flexDirection: "column",
            }}
          >
            <div
              style={{
                height: 160,
                width: 158,
                border: "1px solid grey",
                borderTopRightRadius: "5px",
                borderTopLeftRadius: "5px",
              }}
            >
              {direPlayer5 ? (
                <img src={direPlayer5.avatarUrl} width={158} height={160} />
              ) : (
                <div
                  style={{
                    height: 160,
                    width: 158,
                    flexDirection: "column",
                    justifyContent: "center",
                    display: "flex",
                  }}
                >
                  <Typography
                    style={{
                      textAlign: "center",
                      margin: "auto",
                    }}
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1 }}
                  >
                    Игрок 5
                  </Typography>
                </div>
              )}
            </div>
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={players}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direPlayer5 ? "" : "Выбрать игрока"}
                />
              )}
              onChange={(event, value) => setDirePlayer5(value)}
            />
            <Autocomplete
              disablePortal
              id="combo-box-demo"
              options={heroes}
              sx={{ width: 160 }}
              getOptionLabel={(data) => data.name}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={direHero5 ? "" : "Выбрать героя"}
                />
              )}
              onChange={(event, value) => setDireHero5(value)}
            />
          </div>
        </div>
        <div
          style={{
            flexDirection: "row",
            display: "flex",
            justifyContent: "center",
            marginTop: "64px",
          }}
        >
          <Button variant={"contained"} onClick={() => predict()}>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Сделать прогноз
            </Typography>
          </Button>
        </div>
        {prediction ? (
          <div
            style={{
              flexDirection: "column",
              display: "flex",
              justifyContent: "space-between",
              alignItems: "start",
              marginTop: "24px",
            }}
          >
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Фаворит на основе анализа команд:{" "}
              {prediction[0] == 1 ? "Силы света" : "Силы тьмы"}
            </Typography>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Фаворит на основе анализа героев:{" "}
              {prediction[1] == 1 ? "Силы света" : "Силы тьмы"}
            </Typography>
            <div style={{ height: "24px" }}></div>
          </div>
        ) : (
          <div></div>
        )}
      </div>
    </div>
  );
}

export default Prediction;
