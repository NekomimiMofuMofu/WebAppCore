<template>
  <div>
  <div class="loginForm">
    <h1>Login</h1>
      <div ><input class="id" id="i_user_id" type="text" placeholder="UserName" name="i_user_id" v-model="user_id" ></div>
      <div ><input class="pw" id="i_password" type="password" placeholder="PassWord" name="i_password" v-model="password"></div>
      <div ><button class="btn" id="btn_SignIn" type="button" @click="onClick_In" name="btn_SignIn" >Sign In</button></div>
      <div ><button class="btn" id="btn_SignUp" type="button" @click="onClick_Up" name="btn_SignUp" >Sign Up</button></div>
  </div>
  </div>
</template>

<script lang="ts">
import {Vue} from "vue-property-decorator";
import Component from "vue-class-component";

@Component
export default class LoginPage extends Vue {
  private user_id = "";
  private password = "";
  private id_validate = "root";
  private pass_validate = "password";

  private error_message = "IDかパスワードが間違ってるよ";
  
  private onClick_In(): void {
    //ログインボタン
    if(this.user_id == this.id_validate && this.password == this.pass_validate){
      this.$router.push("/about");
    }else {
      alert(this.error_message);
    }
  }
  private onClick_Up(): void {
    //アカウント作成ページに飛ぶ
    this.$router.push("/CreateAccountPage")
  }
}
</script>

<style scoped lang="scss">

*{
  margin: 0;
  padding: 0;
  text-decoration: none;
  font-family:sans-serif;

}

.loginForm {
  position:absolute;
  width: 350px;
  height: 500px;
  padding: 30px 20px;
  background-color:#FFFFFF;
  text-align: center;
  top:50%;
  left: 50%;
  transform: translate(-50%,-50%);
  border-radius: 15px;
  
  h1 {
    text-align: center;
    margin: 20px;
    color: #76f8e2;
    
  }
  
  .id{
    border-bottom: 2px solid #adadad;
    margin: 30px;
    padding: 10px 10px;
  }
  
  .pw{
    border-bottom: 2px solid #adadad;
    margin: 30px;
    padding: 10px 10px;
  }
}

input{
  position: center;
  width: 80%;
  border:none;
  outline: none;
  color: #636e72;
  font-size: 19px;
  height: 25px;
  background: none;
}

.btn {
  position: relative;
  left: 40%;
  transform: translateX(-50%);
  margin-bottom: 40px;
  width: 80%;
  height: 40px;
  background: linear-gradient(125deg, #81ecec, #6c5ce7, #81ecec);
  background-position: left;
  background-size: 200%;
  color: white;
  font-weight: bold;
  border: none;
  cursor: pointer;
  transition: 0.4s;
  display: inline;
}

.btn:hover {
  background-position: right;
}

</style>