import * as React from "react";
import { useState } from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers";
import dayjs, { Dayjs } from "dayjs";

export default function SelectDateDialog(props: {
  onSelected: (startDate: Date, endDate: Date) => void;
  showDialog: boolean;
  close: () => void;
}) {
  const [startPeriodDate, setStartPeriodDate] = useState<Dayjs | null>(
    dayjs(Date.now())
  );
  const [endPeriodDate, setEndPeriodDate] = useState<Dayjs | null>(
    dayjs(Date.now())
  );
  // const handleChange = (event: SelectChangeEvent<typeof age>) => {
  //   setAge(Number(event.target.value) || "");
  // };

  const handleClose = (
    event: React.SyntheticEvent<unknown>,
    reason?: string
  ) => {
    if (reason !== "backdropClick") {
      props.close();
    }
  };

  return (
    <div>
      <Dialog disableEscapeKeyDown open={props.showDialog}>
        <DialogTitle>Укажите период</DialogTitle>
        <DialogContent>
          <Box
            style={{ margin: "10px" }}
            component="form"
            sx={{ display: "flex", flexWrap: "wrap" }}
          >
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                label="Начало периода"
                value={endPeriodDate}
                onChange={setStartPeriodDate}
              />
              <div style={{ width: "10px" }}></div>
              <DatePicker
                label="Конец периода"
                value={endPeriodDate}
                onChange={setEndPeriodDate}
              />
            </LocalizationProvider>
          </Box>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Закрыть</Button>
          <Button
            onClick={() => {
              props.onSelected(
                startPeriodDate?.toDate()!,
                endPeriodDate?.toDate()!
              );
              props.close();
            }}
          >
            Сохранить
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
