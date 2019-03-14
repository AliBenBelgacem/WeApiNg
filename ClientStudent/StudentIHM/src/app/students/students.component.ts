import { Component, OnInit,Input } from '@angular/core';
import {  
  trigger,  
  state,  
  style,  
  transition,  
  animate,  
  keyframes } from '@angular/animations';  
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';

@Component({  
    selector: 'students'   
   ,  
       
    animations: [  
  
        trigger('buttonReSize', [  
            state('inactive', style({  
                transform: 'scale(1)',  
                backgroundColor: '#f83500'  
            })),  
            state('active', style({  
                transform: 'scale(1.4)',  
                backgroundColor: '#0094ff'  
            })),  
            transition('inactive => active', animate('100ms ease-in')),  
            transition('active => inactive', animate('100ms ease-out'))  
        ]),  
  
        trigger('moveBottom', [  
  
            transition('void => *', [  
                animate(900, keyframes([  
                    style({ opacity: 0, transform: 'translateY(-200px)', offset: 0 }),  
                    style({ opacity: 1, transform: 'translateY(25px)', offset: .75 }),  
                    style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),  
                      
                ]))  
            ])  
  
        ]),  
        trigger('moveTop', [  
  
            transition('void => *', [  
                animate(900, keyframes([  
                    style({ opacity: 0, transform: 'translateY(+400px)', offset: 0 }),  
                    style({ opacity: 1, transform: 'translateY(25px)', offset: .75 }),  
                    style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),  
  
                ]))  
            ])  
  
        ]),  
         
        trigger('moveRight', [  
  
            transition('void => *', [  
                animate(900, keyframes([  
                    style({ opacity: 0, transform: 'translateX(-400px)', offset: 0 }),  
                    style({ opacity: 1, transform: 'translateX(25px)', offset: .75 }),  
                    style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),  
  
                ]))  
            ])  
  
        ]),  
        trigger('movelLeft', [  
  
            transition('void => *', [  
                animate(900, keyframes([  
                    style({ opacity: 0, transform: 'translateX(+400px)', offset: 0 }),  
                    style({ opacity: 1, transform: 'translateX(25px)', offset: .75 }),  
                    style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),  
  
                ]))  
            ])  
  
        ]),  
        trigger('fadeIn', [  
            transition('* => *', [  
                animate('1s', keyframes([  
                    style({ opacity: 0, transform: 'translateX(0)', offset: 0 }),  
                    style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),  
                ]))  
            ])  
        ]),  
  
         
    ],  
    template: require('./students.component.html')  
})  
  
export class StudentsComponent {  
      // to get the Student Details  
    public student: StudentMasters[] = [];   
    // to hide and Show Insert/Edit   
    AddstudetnsTable: Boolean = false;  
    // To stored Student Informations for insert/Update and Delete  
    public StdIDs = "0";  
    public StdNames  = "";  
    public Emails = "";  
    public Phones = "";  
    public Addresss= "";  
  
    //For display Edit and Delete Images  
    public imgEdit = require("./Images/edit.png");  
    public imgDelete = require("./Images/delete.png");  
  
    myName: string;  
    //for animation status   
    animStatus: string = 'inactive';  
    constructor(public http: HttpClient) {  
        console.log('constructor');
        this.myName = "Shanu";  
        this.AddstudetnsTable = false;  
        this.getData();  
    }  
  
    //for Animation to toggle Active and Inactive  
    animButton() {  
        
        this.animStatus = (this.animStatus === 'inactive' ? 'active' : 'inactive');  
    }  
  
    //to get all the Student data from Web API  
    getData()
    {  
        this.http.get('http://localhost:63402/api/StudentMasters').subscribe((result:StudentMasters[]) => {    
            this.student = result;             
        });  
        
    }  
  
  
    // to show form for add new Student Information  
    AddStudent() {  
        this.animButton();  
        this.AddstudetnsTable = true;   
    this.StdIDs = "0";  
    this.StdNames = "";  
    this.Emails = "";  
    this.Phones = "";  
    this.Addresss = "";  
    }  
  
    // to show form for edit Student Information  
    editStudentsDetails(StdID, StdName, Email, Phone, Address) {  
        this.animButton();  
        this.AddstudetnsTable = true;  
        this.StdIDs = StdID;  
        this.StdNames = StdName;  
        this.Emails = Email;  
        this.Phones = Phone;  
        this.Addresss = Address;  
    }  
  
    // If the studentid is 0 then insert the student infromation using post and if the student id is more than 0 then edit using put mehod  
    addStudentsDetails(StdID, StdName, Email, Phone, Address) {  
        alert(StdName);  
        var headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        //headers.append('Content-Type', 'application/json; charset=utf-8');  
        if (StdID == 0)  
        {  
            this.http.post('http://localhost:63402/api/StudentMasters', JSON.stringify({ StdID: StdID, StdName: StdName, Email: Email, Phone: Phone, Address: Address }), { headers: headers })
            .subscribe(
                (value) => {
                 
                },
                (error) => {
                  console.log('Uh-oh, an error occurred! : ' + error);
                },
                () => {
                    this.getData()
                  console.log('Observable complete!');
                })
            alert("Student Detail Inserted");  
        }  
        else  
        {  
            console.log(StdID);
            console.log(JSON.stringify({ StdID: StdID, StdName: StdName, Email: Email, Phone: Phone, Address: Address }));
            this.http.put('http://localhost:63402/api/StudentMasters/' + StdID, JSON.stringify({ StdID: StdID, StdName: StdName, Email: Email, Phone: Phone, Address: Address }), { headers: headers })
            .subscribe(
                (value) => {
                  
                },
                (error) => {
                  console.log('Uh-oh, an error occurred! : ' + error);
                },
                () => {
                    this.getData()
                    alert("Student Detail Updated"); 
                  console.log('Observable complete!');
                })
            
        }         
        
        this.AddstudetnsTable = false;   
       // this.getData();           
    }  
  
    //to Delete the selected student detail from database.  
    deleteStudentsDetails(StdID) {   
        console.log(StdID) ;       
        var headers = new HttpHeaders();  
        headers.append('Content-Type', 'application/json; charset=utf-8');  
         
        this.http.delete('http://localhost:63402/api/StudentMasters/' + StdID, { headers: headers }) .subscribe(
            (value) => {
             
            },
            (error) => {
              console.log('Uh-oh, an error occurred! : ' + error);
            },
            () => {
                this.getData()
              console.log('Observable complete!');
              alert("Student Detail Deleted"); 
            }); 
             
            //this.getData();          
    }  
  
    closeEdits()  
    {  
        this.AddstudetnsTable = false;  
        this.StdIDs = "0";  
        this.StdNames = "";  
        this.Emails = "";  
        this.Phones = "";  
        this.Addresss = "";  
    }  
}  
  
export interface StudentMasters {  
    StdID: number;  
    StdName: string;  
    Email: string;  
    Phone: string;  
    Address: string;  
}   
