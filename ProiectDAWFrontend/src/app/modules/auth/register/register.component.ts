import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {

  public profileForm: FormGroup = new FormGroup({
    nume: new FormControl(''),
    prenume: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl(''),
  });

  public error: string | boolean = false;

  constructor(private router: Router,
    private dataService: DataService,) { }

  ngOnInit(): void{
  }

  catreLogin()
  {
     this.router.navigateByUrl('/login');
  }

  register()
  {
    this.error = false;
    console.log("Register realizat!");
    if (this.validateEmail(this.profileForm.value.username))  
    {
      console.log(this.profileForm.value)
      this.dataService.changeUserData(this.profileForm.value);
      localStorage.setItem('Role', 'Admin');
      this.router.navigate(['/clienti']);
    }
    else
    {
      this.error = "Email-ul introdus nu este valid!";
    }
  }

  validateEmail(email: string) {
    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }
}
    
  
  


