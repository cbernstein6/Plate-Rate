// src/global.d.ts
declare global {
    interface Window {
      handleCredentialResponse: (response: any) => void;
    }
  }
  
  export {};