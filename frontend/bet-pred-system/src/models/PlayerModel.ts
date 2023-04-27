import { HeroWinRateModel } from "./HeroWinRateModel";

export class PlayerModel {
  id: string;
  name: string;

  avatarUrl: string;

  teamName: string;

  role: string;

  region: string;

  matchesCount: number;
  winRate: number;
  streak: number;

  avgKills: number;
  avgDeths: number;
  avgAssists: number;
  avgPlacedObserverWards: number;
  avgDestroyedObserverWards: number;
  avgPlacedSentryWards: number;
  avgDestroyedSentryWards: number;

  avgCreepsKilled: number;
  avgDenies: number;

  expPerMinute: number;
  goldPerMinute: number;

  heroesWithWinRate: Array<HeroWinRateModel>;

  constructor({
    id,
    name,
    avatarUrl,
    teamName,
    role,
    region,
    matchesCount,
    winRate,
    streak,
    avgKills,
    avgDeths,
    avgAssists,
    avgPlacedObserverWards,
    avgDestroyedObserverWards,
    avgPlacedSentryWards,
    avgDestroyedSentryWards,
    avgCreepsKilled,
    avgDenies,
    expPerMinute,
    goldPerMinute,
    heroesWithWinRate,
  }: {
    id: string;
    name: string;
    avatarUrl: string;
    teamName: string;
    role: string;
    region: string;
    matchesCount: number;
    winRate: number;
    streak: number;
    avgKills: number;
    avgDeths: number;
    avgAssists: number;
    avgPlacedObserverWards: number;
    avgDestroyedObserverWards: number;
    avgPlacedSentryWards: number;
    avgDestroyedSentryWards: number;
    avgCreepsKilled: number;
    avgDenies: number;
    expPerMinute: number;
    goldPerMinute: number;
    heroesWithWinRate: Array<HeroWinRateModel>;
  }) {
    this.id = id;
    this.name = name;
    this.avatarUrl = avatarUrl;
    this.teamName = teamName;
    this.role = role;
    this.region = region;
    this.matchesCount = matchesCount;
    this.winRate = winRate;
    this.streak = streak;
    this.avgKills = avgKills;
    this.avgDeths = avgDeths;
    this.avgAssists = avgAssists;
    this.avgPlacedObserverWards = avgPlacedObserverWards;
    this.avgDestroyedObserverWards = avgDestroyedObserverWards;
    this.avgPlacedSentryWards = avgPlacedSentryWards;
    this.avgDestroyedSentryWards = avgDestroyedSentryWards;
    this.avgCreepsKilled = avgCreepsKilled;
    this.avgDenies = avgDenies;
    this.expPerMinute = expPerMinute;
    this.goldPerMinute = goldPerMinute;
    this.heroesWithWinRate = heroesWithWinRate;
  }
}
