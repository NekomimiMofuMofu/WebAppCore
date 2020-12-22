<template>
  <div class="context">
    <h1>アカウント新規作成</h1>
    <dl class="Account">
      <div>
        <div><input class="input" type="text" name="name" placeholder="ユーザーネーム" id="name"></div>
        <div><input class="input" type="email" name="mail" placeholder="メールアドレス" id="mail"></div>
        <div><input class="input" type="email" name="re-mail" placeholder="メールアドレス(確認)" id="re-mail"></div>
        <div><input class="input" type="password" name="password" placeholder="パスワード" id="password"></div>
        <div><input class="input" type="password" name="re-password" placeholder="パスワード(確認)" id="re-password"></div>
        <div><input class="btn" type="button" @click="onClick" id="btn_create" name="btn_create" value="アカウント作成"></div>
      </div>
    </dl>
  </div>
</template>

<script lang="ts">
import {Vue} from "vue-property-decorator";
import Component from "vue-class-component";

@Component
export default class CreateAccountPage extends Vue {
  private a = false;
  
  private onClick(): void {
    this.a = true;
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

.context {
  position:absolute;
  width: 400px;
  height: 600px;
  padding: 50px 30px;
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
.input {
  border-bottom: 2px solid #adadad;
  margin: 20px;
  padding: 10px 10px;
}

.btn{
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
