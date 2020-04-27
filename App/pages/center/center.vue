<template>
	<view class="center">
		<view class="logo" @click="goLogin" :hover-class="!login ? 'logo-hover' : ''">
			<image class="logo-img" :src="login ? uerInfo.avatarUrl :avatarUrl"></image>
			<view class="logo-title">
				<text class="uer-name">Hi，{{login ? uerInfo.name : '您未登录'}}</text>
				<text class="go-login navigat-arrow" v-if="!login">&#xe65e;</text>
			</view>
		</view>
		<view class="center-list">
			<view class="center-list-item border-bottom">
				<text class="list-icon">&#xe60c;</text>
				<text class="list-text">账单</text>
				<text class="navigat-arrow">&#xe65e;</text>
			</view>
			<view class="center-list-item" @click="goAbout">
				<text class="list-icon">&#xe603;</text>
				<text class="list-text">关于</text>
				<text class="navigat-arrow">&#xe65e;</text>
			</view>
		</view>
	</view>
	</view>
</template>

<script>
	import config from '../../config.js'
	import util from '../../utils/util.js'

	export default {
		data() {
			return {
				login: false,
				avatarUrl: '/static/logo.png',
				uerInfo: {
					name: '丹麦的面包不单卖'
				}
			}
		},
		methods: {
			goLogin() {
				if (!this.login) {
					uni.navigateTo({
						url: '/pages/login/login'
					});
				}
			},
			goAbout() {
				uni.navigateTo({
					url: '/pages/about/about'
				});
			}
		},
		onLoad: function(options) {
			let user = util.getUser();
			this.login = user.Token != 'undefined';
			if (this.login) {
				var name = user.UserInfo.RealName;

				if (name == '超级管理员') {
					name = '丹麦的面包不单卖';
				}

				this.uerInfo.name = name;
			}
		}
	}
</script>

<style>
</style>
