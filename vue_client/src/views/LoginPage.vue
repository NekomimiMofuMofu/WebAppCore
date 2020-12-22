<template>
  <div class="login">
    <h1>Login</h1>
    <dl class="login_input">
      <dt><label for="i_user_id">UserName</label></dt>
      <dt><input id="i_user_id" type="text" placeholder="" name="i_user_id" v-model="user_id"></dt>
      <dt><label for="i_password">PassWord</label></dt>
      <dt><input id="i_password" type="password" placeholder="" name="i_password" v-model="password"></dt>
      <dt>
        <button class="btn" id="btn_SignIn" type="button" @click="onClick_In" name="btn_SignIn" >Sign In</button>
        <button class="btn" id="btn_SignUp" type="button" @click="onClick_Up" name="btn_SignUp" >Sign Up</button>
      </dt>
    </dl>
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
.login {
  margin: 50px;
  padding: 20px;
  
  
  .login_input {
    
  }
  
}

h1 {
  color: #76f8e2;
  font-size: 75px;
}

label {
  
  padding-right: 90px ;
}

.btn {
  
  padding: 5px 10px;
  margin: 10px;
}



</style>