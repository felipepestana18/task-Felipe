import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  tasks: any;
  filterTask: String = '';
  ngOnInit(): void {
    this.getDataTask();
  }
  constructor(private taskService: TaskService, private router: Router) { }

  getDataTask() {
    this.taskService.getData().subscribe((data: any) => {
      console.log(data);
      this.tasks = data;
    })
  }

  deleteTask(id: number) {

    this.taskService.deleteData(id).subscribe((data: any) => {
      this.getDataTask();
    })
  }

  updateTask(id: number) {
    this.router.navigateByUrl('create/' + id);
  }

  taskDone(id: number) {
    this.taskService.doneData(id).subscribe((data: any) => {
      this.getDataTask();
    })
  }
  reserarchTask() {
    if (this.filterTask) {
      this.taskService.getDataFilter({ title: this.filterTask }).subscribe((data: any) => {
        this.tasks = data;
      })
    }
  }

}
