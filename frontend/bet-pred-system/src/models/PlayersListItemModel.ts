export class PlayersListItemModel {
  id: string;
  name: string;

  avatarUrl: string;

  teamName: string;

  role: string;

  region: string;

  constructor({
    id,
    name,
    avatarUrl,
    teamName,
    role,
    region,
  }: {
    id: string;
    name: string;
    avatarUrl: string;
    teamName: string;
    role: string;
    region: string;
  }) {
    this.id = id;
    this.name = name;
    this.avatarUrl = avatarUrl;
    this.teamName = teamName;
    this.role = role;
    this.region = region;
  }
}
