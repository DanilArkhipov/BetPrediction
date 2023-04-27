import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import { Pagination } from "@mui/material";

export default function BottomMenu(params: {
  onPageChanged: (pageNumber: number) => void;
  pagesCount: number;
}) {
  const [page, setPage] = React.useState(1);
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    if (value == page) return;
    setPage(value);
    params.onPageChanged(value);
  };

  return (
    <Box>
      <AppBar position="fixed" color="primary" sx={{ top: "auto", bottom: 0 }}>
        <Toolbar>
          <Pagination
            count={params.pagesCount}
            page={page}
            onChange={handleChange}
          />
        </Toolbar>
      </AppBar>
    </Box>
  );
}
