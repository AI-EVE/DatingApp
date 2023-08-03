export class LoginResponse {
  username: string;
  token: string;
  photoUrl: string;
  knownAs: string;

  constructor(
    username: string,
    token: string,
    photoUrl: string,
    knownAs: string
  ) {
    this.username = username;
    this.token = token;
    this.photoUrl = photoUrl;
    this.knownAs = knownAs;
  }
}
