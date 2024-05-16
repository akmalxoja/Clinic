import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

const token = "accessToken"

import { jwtDecode } from 'jwt-decode';

export const clinicGuard: CanActivateFn = (route, state) => {
  if(localStorage.getItem(token) == null || localStorage.getItem(token) == "" || localStorage.getItem(token) == undefined)
  {
    inject(Router).navigateByUrl('/login')
    return false;
  } 
  return true;
};

export const adminGuard: CanActivateFn = (route, state) => {
  const localToken = localStorage.getItem(token);
  if (!localToken || localToken === "") {
    inject(Router).navigateByUrl('/login');
    return false;
  } else {
    try {
      const decodedToken: any = jwtDecode(localToken);
      const role = decodedToken.role;
      if (role !== 'Admin') {
        inject(Router).navigateByUrl('/notfound');
        return false;
      }
    } catch (error) {
      console.error("Error decoding token:", error);
      inject(Router).navigateByUrl('/login');
      return false;
    }
  }
  return true;
};


export const expireGuard: CanActivateFn = (route, state) => {
  const localToken = localStorage.getItem(token);
  if (!localToken || localToken === "") {
    inject(Router).navigateByUrl('/login');
    return false;
  }
  console.log(token)
  const decodedToken: any = jwtDecode(localToken);
  const expirationTime = decodedToken.exp * 1000;
  const currentTime = Date.now();
  if (currentTime > expirationTime) {
    inject(Router).navigateByUrl('/login');
    return false;
  }
  return true
};