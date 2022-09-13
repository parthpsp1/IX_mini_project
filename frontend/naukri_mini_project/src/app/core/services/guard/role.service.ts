// import { Injectable } from '@angular/core';
// import { CanActivate } from '@angular/router';

// @Injectable({
//   providedIn: 'root'
// })
// export class RoleService implements CanActivate{

//   constructor(private auth: AuthService) { }
// }



// export class RoleGuard implements CanActivate {
//   constructor (private myAuth: AuthenticationService) {}
//   canActivate() {
//     //debugger;
//     let Role = this.myAuth.getRole();
//     if (Role == 'Admin') {
//       return true;
//     }  else{
//       return false;
//     }
//   }
// }