import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpClient,  HttpInterceptor, HttpRequest, HttpErrorResponse, HttpHandler, HttpEvent, HttpResponse  } from '@angular/common/http';
//import { Observable } from 'rxjs';
//import 'rxjs/add/operator/catch';

import { PlanoEmbarque } from 'src/app/model/PlanoEmbarque';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { Injectable } from '@angular/core';
import { Observable, EMPTY, throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { filterResponse, uploadProgress } from '../../shared/rxjs-operators';
import { environment } from '../../../environments/environment';

import { UploadFileService } from 'src/app/service/uploadfile/upload-file.service'; //Loiane

import { PlanoEmbarqueService } from 'src/app/service/planoembarque/PlanoEmbarque.service';

@Component({
  selector: 'app-excelimport',
  templateUrl: './excelimport.component.html'
})
export class ExcelimportComponent implements OnInit {

  //@ViewChild('fileInput2', {static: true}) fileInput2: ElementRef;
  @ViewChild('fileInput2') fileInput2: ElementRef;
  @ViewChild('fileInput') fileInput;

  message: string;
  allPlanoEmbarque: Observable<PlanoEmbarque[]>;

  files: Set<File>;  //Loiane
  progress = 0;      //Loiane


  constructor(private http: HttpClient, private planoEmbarqueService: PlanoEmbarqueService, private uploadFileService: UploadFileService) { }

  ngOnInit() {
    this.loadallPlanoEmbarque();
  }

  loadallPlanoEmbarque() {
    this.allPlanoEmbarque = this.planoEmbarqueService.BindPlanoEmbarque();
  }

  uploadFile() {

    if (!this.fileInput.nativeElement.files.length) {
      console.log('Arquivo Vazio!!');
      debugger
      return;
    }
    let formData = new FormData();
    formData.append('upload', this.fileInput.nativeElement.files[0])
    debugger
    //console.log(formData);
    console.log(this.fileInput.nativeElement.files[0]);

    this.planoEmbarqueService.UploadExcel(formData).subscribe(result => {
      this.message = result.toString();
      this.loadallPlanoEmbarque();
    });
  }

  // testUpload() {
  //   if (!this.fileInput2.nativeElement.files.length) {
  //     console.log('Arquivo Vazio!!');
  //     debugger
  //     return;
  //   }
  //   const data = new FormData();
  //   data.append('testFile', this.fileInput2.nativeElement.files[0], this.fileInput2.nativeElement.files[0].name);
  //   console.log(data);
  //   debugger
  //   this.http.post('http://localhost:51600/api/Excel/UploadExcel', data).subscribe((res: Response) => {
  //     console.log(res);
  //   });
  // }

  //Loiane
  onChange(event) {
    console.log(event);

    const selectedFiles = <FileList>event.srcElement.files;
    // document.getElementById('customFileLabel').innerHTML = selectedFiles[0].name;

    const fileNames = [];
    this.files = new Set();
    for (let i = 0; i < selectedFiles.length; i++) {
      fileNames.push(selectedFiles[i].name);
      this.files.add(selectedFiles[i]);
    }
    document.getElementById('customFileLabel').innerHTML = fileNames.join(', ');

    this.progress = 0;
  }

  onUpload() {
    if (this.files && this.files.size > 0) {
      this.uploadFileService.upload(this.files, environment.BASE_URL + '/api/Excel/UploadExcel')
        .pipe(
          uploadProgress(progress => {
            console.log(progress);
            this.progress = progress;
          }),
          filterResponse()
        )
        .subscribe(response => console.log('Upload Concluído'));
        // .subscribe((event: HttpEvent<Object>) => {
        //   // console.log(event);
        //   if (event.type === HttpEventType.Response) {
        //     console.log('Upload Concluído');
        //   } else if (event.type === HttpEventType.UploadProgress) {
        //     const percentDone = Math.round((event.loaded * 100) / event.total);
        //     // console.log('Progresso', percentDone);
        //     this.progress = percentDone;
        //   }
        // } );
    }
  }
}
