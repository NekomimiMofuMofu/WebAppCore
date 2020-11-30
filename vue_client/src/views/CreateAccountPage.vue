<template>
  <div class="CreateAccountPage">
    <h1>アカウント新規作成</h1>
    <label for="name">ID</label>
    <input type="text" name="name" id="name">
    <label for="mailaddress">メールアドレス</label>
    <input type="email" name="mailaddress" id="mailaddress">
    <label for="re-entermailaddress">メールアドレス(確認)</label>
    <input type="email" name="re-entermailaddress" id="re-entermailaddress">
    <label for="password">パスワード</label>
    <input type="password" name="password" id="password">
    <label for="re-enterpassword">パスワード(確認)</label>
    <input type="re-enterpassword" name="re-enterpassword" id="re-enterpassword">
    <input type="button" @click="onClick" id="btn_createaccount" name="btn_createaccount" value="アカウント作成">
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

