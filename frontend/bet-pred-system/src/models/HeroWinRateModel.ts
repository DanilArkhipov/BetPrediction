export class HeroWinRateModel {
  id: string;
  name: string;
  winRate: number;

  heroIconUrl: string;

  gamesCount: string;

  constructor({
    id,
    name,
    winRate,
    heroIconUrl,
    gamesCount,
  }: {
    id: string;
    name: string;
    winRate: number;
    heroIconUrl: string;
    gamesCount: string;
  }) {
    this.id = id;
    this.name = name;
    this.winRate = winRate;
    this.heroIconUrl = heroIconUrl;
    this.gamesCount = gamesCount;
  }
}
