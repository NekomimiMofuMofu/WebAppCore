<template>
  <div class="context">
    <h1>アカウント新規作成</h1>
    <dl class="Account">
      <div>
        <div class="input-label"><label for="name">ID</label></div>  
        <div><input type="text" name="name" id="name"></div>
        <div class="input-label"><label for="mail">メールアドレス</label></div>  
        <div><input type="email" name="mail" id="mail"></div>
        <div class="input-label"><label for="re-mail">メールアドレス(確認)</label></div>  
        <div><input type="email" name="re-mail" id="re-mail"></div>
        <div class="input-label"><label for="password">PassWord</label></div>  
        <div><input type="password" name="password" id="password"></div>
        <div class="input-label"><label for="re-password">パスワード(確認)</label></div>  
        <div><input type="password" name="re-password" id="re-password"></div>
        <div class="input-label"><input type="button" @click="onClick" id="btn_create" name="btn_create" value="アカウント作成"></div>
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
.context {
  margin: 50px;
  padding: 50px;
  
  .input-label {
    text-align: left;
    margin-left: 30%;
  }
}


</style>
