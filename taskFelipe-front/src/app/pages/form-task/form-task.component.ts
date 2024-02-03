import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-form-task',
  templateUrl: './form-task.component.html',
  styleUrls: ['./form-task.component.scss']
})
export class FormTaskComponent {


  constructor(private formBuilder: FormBuilder, private taskService: TaskService, private router: Router, private activeRoute: ActivatedRoute) { }

  filter: any
  id: any

  ngOnInit(): void {
    this.activeRoute.params.subscribe(res => this.filter = res);

    if (this.filter.id > 0) {
      this.id = this.filter.id
      this.getDataTask();
    }
  }

  public cadastroForm: FormGroup = this.formBuilder.group({
    title: ['', Validators.required],
    description: ['', Validators.required]
  })


  getDataTask() {
    this.taskService.getDataFilter(this.filter).subscribe((data: any = []) => {
      this.cadastroForm.controls['title'].setValue(data[0]['title']);
      this.cadastroForm.controls['description'].setValue(data[0]['title']);
    })
  }

  SubmitForm() {
    if (!this.cadastroForm.invalid) {
      if (this.id)
        this.EditTask()
      else
        this.CreateTask()
    }
  }

  EditTask() {
    this.taskService.putData(this.id, this.cadastroForm.value).subscribe((data) => {
      if (data) {
        this.router.navigateByUrl('');
      }
    })
  }
  CreateTask() {
    this.taskService.postData(this.cadastroForm.value).subscribe((data) => {
      if (data) {
        this.router.navigateByUrl('');
      }
    })
  }
}
