<template>
	<form class='loginView' @submit="login">
		<view class="input-view">
			<view class="label-view">
				<text class="label">账号 </text>
			</view>
			<input class="input" type="text" placeholder="请输入用户名" name="userName" />
		</view>
		<view class="input-view">
			<view class="label-view">
				<text class="label">密码</text>
			</view>
			<input class="input" type="password" placeholder="请输入密码" name="password" />
		</view>
		<view class="button-view">
			<button type="default" class="login" hover-class="hover" formType="submit">登录</button>
			<button type="default" class="register" hover-class="hover" @click="register">免费注册</button>
		</view>
	</form>
</template>

<script>
	import config from '../../config.js'
	import util from '../../utils/util.js'
	
	export default {
		data() {
			return {
				loading: false,
				title: config.info.title,
				redirect: encodeURIComponent('/pages/center/center'),
			}
		},
		methods: {
			login(e) {
				let that = this
				
				if (config.debug) console.log("formSubmit", e);
				if (that.loading) return;
				
				if (e.detail.value.password == '' || e.detail.value.username == '') {
					util.toastError('账号和密码均不能为空')
					return
				}
				
				that.loading = true
				
				util.request(config.api.login, e.detail.value, 'POST').then((res) => {
					if (config.debug) console.log(config.api.login, res);
					let user = res.Data
					if (user == undefined || user.Token == '') {
						util.toastError('登录失败：未知错误')
						that.loading = false
						return
					}
					util.setUser(user)
					util.toastSuccess('登录成功')
					setTimeout(function() {
						let url = decodeURIComponent(that.redirect)
						if (url.indexOf("?") > -1) {
							uni.redirectTo({
								url: url
							})
						} else {
							uni.switchTab({
								url: url
							})
						}
					}, 1500)
				}).catch((e) => {
					if (config.debug) console.log(e);
					that.loading = false
					util.toastError(e.data.message || e.errMsg)
				})
			},
			register() {
				console.log("前往注册页面")
			}
		},
		onLoad: () => {
			let token = util.getToken()
			if (token) {
				let url = decodeURIComponent(this.redirect)
				if (url.indexOf("?") > -1) {
					uni.redirectTo({
						url: url
					})
				} else {
					uni.switchTab({
						url: url
					})
				}
			}
		}
	}
</script>

<style>
	
</style>
