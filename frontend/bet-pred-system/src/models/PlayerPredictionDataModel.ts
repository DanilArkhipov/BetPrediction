export class PlayerPredictionModel {
  id: string;
  name: string;

  avatarUrl: string;

  constructor({
    id,
    name,
    avatarUrl,
  }: {
    id: string;
    name: string;
    avatarUrl: string;
  }) {
    this.id = id;
    this.name = name;
    this.avatarUrl = avatarUrl;
  }
}
