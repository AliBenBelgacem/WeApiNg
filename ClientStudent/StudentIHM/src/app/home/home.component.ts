import { Component, OnInit,Input } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition,
  keyframes,
} from '@angular/animations';
@Component({
  selector: 'home',
  animations: [    
    trigger('moveBottom', [  
        transition('void => *', [  
            animate('1s', keyframes([  
                style({ opacity: 0, transform: 'translateY(-200px)', offset: 0 }),  
                style({ opacity: 1, transform: 'translateY(25px)', offset: .75 }),  
                style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),  

            ]))  
        ])  

    ]),  
    trigger('moveTop', [  

        transition('void => *', [  
            animate('1s', keyframes([  
                style({ opacity: 0, transform: 'translateY(+400px)', offset: 0 }),  
                style({ opacity: 1, transform: 'translateY(25px)', offset: .75 }),  
                style({ opacity: 1, transform: 'translateY(0)', offset: 1 }),  

            ]))  
        ])  

    ]), 
    trigger('moveRight', [  
  
      transition('void => *', [  
          animate('1s', keyframes([  
              style({ opacity: 0, transform: 'translateX(-400px)', offset: 0 }),  
              style({ opacity: 1, transform: 'translateX(25px)', offset: .75 }),  
              style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),  

          ]))  
      ])  

  ]),  
  trigger('movelLeft', [  

      transition('void => *', [  
          animate('4s', keyframes([  
              style({ opacity: 0, transform: 'translateX(+800px)', offset: 0 }),  
              style({ opacity: 1, transform: 'translateX(150px)', offset: .75 }),  
              style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),  

          ]))  
      ])  

  ]),  
  trigger('fadeIn', [  

      transition('void => *', [  
          animate('3s', keyframes([  
              style({ opacity: 0, transform: 'translateX(0)', offset: 0 }),  
              style({ opacity: 1, transform: 'translateX(0)', offset: 1 }),  
          ]))  
      ])  
  ])  
],   
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  myName: string = "Shanu";  
  constructor() { }

  ngOnInit() {
  }

}
