import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-changelogmaster',
  templateUrl: './changelogmaster.component.html',
  styleUrls: ['./changelogmaster.component.css']
})
export class ChangelogmasterComponent implements OnInit {

  frm: FormGroup;

  constructor(private builder: FormBuilder) { }

  ngOnInit() {
    this.frm = this.builder.group({
      titulo: ['', Validators.required],
      mensagem: ['', Validators.required]
    })
  }

}
