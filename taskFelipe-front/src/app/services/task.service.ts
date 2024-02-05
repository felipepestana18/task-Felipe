import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class TaskService {

  private url: string = "http://localhost:4400/api/v1/task/";

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getData() {
    return this.http.get(this.url + 'find-all');
  }

  getDataFilter(filter: any) {

    return this.http.post(this.url + 'task-filter', filter)
  }

  postData(formData: any) {
    return this.http.post(this.url + 'create', formData);
  }

  putData(id: number, formData: any) {
    return this.http.put(this.url + 'update', formData);
  }

  deleteData(id: number) {
    return this.http.delete(this.url + 'delete/' + id);
  }

  doneData(id: number) {
    return this.http.put(this.url + 'done/' + id, '');
  }
}
