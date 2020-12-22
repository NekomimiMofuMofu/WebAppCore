<template>
  <div class="login">
    <h1>ログイン</h1>
    <dl class="login_input">
      <dt><label for="i_user_id">ユーザーID</label></dt>
      <dt><input id="i_user_id" type="text" placeholder="ユーザーID" name="i_user_id" v-model="user_id"></dt>
      <dt><label for="i_password">パスワード</label></dt>
      <dt><input id="i_password" type="password" placeholder="パスワード" name="i_password" v-model="password"></dt>
      <dt><button id="btn_login" type="button" @click="onClick" name="btn_login" >ログイン</button></dt>
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
  
  private onClick(): void {
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
  padding: 20px;
  
  .login_input {
    
  }
  
}

h1 {
  color: #76f8e2;
}

label {
  
  padding-right: 90px ;
}

input {
  
}

</style>