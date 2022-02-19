import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClientiService } from 'src/app/services/clienti.service';

@Component({
  selector: 'app-adauga-updateaza',
  templateUrl: './adauga-updateaza.component.html',
  styleUrls: ['./adauga-updateaza.component.scss']
})
export class AdaugaUpdateazaComponent implements OnInit {

  public ClientForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    nume: new FormControl(''),
    telefon: new FormControl(''),
  });
  constructor(
    @Inject(MAT_DIALOG_DATA) public data : any,
    private clientsService: ClientiService,
    public dialogRef: MatDialogRef<AdaugaUpdateazaComponent>,
  ) {
    console.log(this.data);
    if (data.client){
      this.ClientForm.patchValue(this.data.client);
    }
   }

  ngOnInit(): void {
  }

  public adauga(): void{
    this.clientsService.adaugaClient(this.ClientForm.value).subscribe(
       (result) =>
       {
         console.log(result);
         this.dialogRef.close(result);
       },
       (error) =>
       {
         console.error(error);
       }
    );
  }

  public updateaza():void{
    this.clientsService.updateClient(this.ClientForm.value).subscribe(
      (result) =>
      {
        console.log(result);
        this.dialogRef.close(result);
      },
      (error) =>
      {
        console.error(error);
      }
   );
  }

}
