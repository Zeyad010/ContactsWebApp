import {HttpClient, HttpClientModule} from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
import { AsyncPipe } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, ValueChangeEvent } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HttpClientModule,AsyncPipe,FormsModule,ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  http = inject(HttpClient);

  contactsForm = new FormGroup({

name: new FormControl<string>(''),
email:new FormControl<string|null>(null),
phoneNumber:new FormControl<string>(''),
favorite: new FormControl<boolean>(false)


  })

  contacts$=this.getContacts(); 

  onFormSubmit(){
    const addContactRequest={
      name: this.contactsForm.value.name,
      email: this.contactsForm.value.email,
      phoneNumber: this.contactsForm.value.phoneNumber,
      favorite: this.contactsForm.value.favorite,

    }
  this.http.post('https://localhost:7169/api/Contacts',addContactRequest).subscribe({
    next:(vlaue)=>{
      console.log(vlaue);
      //to get new elements after adding it
      this.contacts$=this.getContacts();
      this.contactsForm.reset();

    }
  });


  }

  // This method will call the API using Http client
  private getContacts():Observable<Contact[]>{

return this.http.get<Contact[]>('https://localhost:7169/api/Contacts');
  
  }
  

}

