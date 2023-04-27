export class TeamsListItemModel {
  id: string;
  teamName: string;

  teamLogoUrl: string;

  teamTag: string;

  totalWins: string;

  totalLosses: string;

  constructor({
    id,
    teamLogoUrl,
    teamName,
    teamTag,
    totalWins,
    totalLosses,
  }: {
    id: string;
    teamLogoUrl: string;
    teamName: string;
    teamTag: string;
    totalWins: string;
    totalLosses: string;
  }) {
    this.id = id;
    this.teamLogoUrl = teamLogoUrl;
    this.teamName = teamName;
    this.teamTag = teamTag;
    this.totalWins = totalWins;
    this.totalLosses = totalLosses;
  }
}
