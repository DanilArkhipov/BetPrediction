import { GridPaginationModel } from "@mui/x-data-grid/models/gridPaginationProps";

export class BaseListModel<ListItem> implements GridPaginationModel {
  items: Array<ListItem>;

  page: number;

  pageSize: number;

  totalItemsCount: number;

  constructor({
    items,
    page,
    pageSize,
    totalItemsCount,
  }: {
    items: Array<ListItem>;
    page: number;
    pageSize: number;
    totalItemsCount: number;
  }) {
    this.items = items;
    this.page = page;
    this.pageSize = pageSize;
    this.totalItemsCount = totalItemsCount;
  }
}
