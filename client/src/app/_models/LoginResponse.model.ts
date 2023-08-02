export class LoginResponse {
  username: string;
  token: string;
  photoUrl: string;

  constructor(username: string, token: string, photoUrl: string) {
    this.username = username;
    this.token = token;
    this.photoUrl = photoUrl;
  }
}
