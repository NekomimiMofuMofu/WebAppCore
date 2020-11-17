<template>
  <div class="login">
    <h1>ログイン</h1>
    <label for="i_user_id">ユーザーID</label>
    <input id="i_user_id" type="text" name="user_id" value="">
    <label for="i_password">パスワード</label>
    <input id="i_password" type="password" name="password" value="">
    <input id="btn_login" type="button" @click="onClick" name="btn_login" value="ログイン">
    <div v-if="a">HogeHoge</div>
    <div v-if="!a">Default</div>
  </div>
</template>

<script lang="ts">
import {Vue} from "vue-property-decorator";
import Component from "vue-class-component";

@Component
export default class LoginPage extends Vue {
  private a = false;
  
  private onClick(): void {
    this.a = true;
  }
}

</script>

<style scoped lang="scss">

</style>