import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Employee } from '../model/employee.model';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {
  public employees: Employee[];
  searchEmployeeForm;
  public Isloading = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {
   
    this.searchEmployeeForm = this.formBuilder.group({
      IdEmployee: '',
    });
  }

  GetEmployees(id: number) { 
    this.http.get<Employee[]>(this.baseUrl + `api/Employee/GetEmployees/${id}`).subscribe(result => {
      this.employees = result;
      this.Isloading = false;
    }, error => console.error(error));
  }

  onSubmit(param: any) {
    this.Isloading = true; 
    if(param.IdEmployee !== ''){
      this.GetEmployees(Number(param.IdEmployee));
    }
    else
    {
      this.GetEmployees(0);
    }
    
    this.searchEmployeeForm.reset();
  }
}




