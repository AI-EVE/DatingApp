import { Component, Input } from '@angular/core';
import { AppUser } from '../_models/appUser.model';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment.development';
import { AccountService } from '../_services/account.service';
import { AppUsersService } from '../_services/app-users.service';
import { Photo } from '../_models/photo';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent {
  @Input() appUser: AppUser | undefined;
  uploader: FileUploader | undefined;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  token: string | null | undefined;

  constructor(
    private accountService: AccountService,
    private appUsersService: AppUsersService
  ) {
    this.token = this.accountService.token;
  }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  setMainPhoto(photo: Photo) {
    this.appUsersService.setMainPhoto(photo.id).subscribe(() => {
      this.appUser!.photoUrl = photo.url;
      this.accountService.photoUrl = photo.url;
      this.appUser!.photos.forEach((p) => {
        if (p.isMain) p.isMain = false;
        if (p.id == photo.id) p.isMain = true;
      });
      this.accountService.updateLoginResponse();
    });
  }

  deletePhoto(photoId: number) {
    this.appUsersService.deletePhoto(photoId).subscribe({
      next: () => {
        if (this.appUser)
          this.appUser!.photos = this.appUser!.photos.filter(
            (x) => x.id !== photoId
          );
      },
    });
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/add-photo',
      authToken: 'Bearer ' + this.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024, // 10 MB
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo = JSON.parse(response);
        this.appUser?.photos.push(photo);
      }
    };
  }
}
