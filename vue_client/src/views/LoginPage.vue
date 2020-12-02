<template>
  <div class="login">
    <h1>Login</h1>
    <dl class="login_input">
      <dt><label for="i_user_id">UserName</label></dt>
      <dt><input id="i_user_id" type="text" placeholder="" name="i_user_id" v-model="user_id"></dt>
      <dt><label for="i_password">PassWord</label></dt>
      <dt><input id="i_password" type="password" placeholder="" name="i_password" v-model="password"></dt>
      <dt>
        <button id="btn_signIn" type="button" @click="onClick1" name="btn_signIn" >Sign In</button>
        <button id="btn_signUp" type="button" @click="onClick2" name="btn_signUp" >Sign Up</button>
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
  
  private onClick1(): void {
    if(this.user_id == this.id_validate && this.password == this.pass_validate){
      this.$router.push("/about");
    }else {
      alert(this.error_message);
    }
  }
  
}

</script>

<style scoped lang="scss">
.login {
  margin: 100px;
  padding: 30px 60px;
  
  .login_input {
    
  }
  
}

h1 {
  color: #76f8e2;
  font-size: xxx-large;
}

label {
  
  padding-right: 90px ;
}

input {
  
}

button {
  
}

</style>