// api host，末尾不要带斜杠。
let host = 'http://localhost:5000'

// 是否是调试模式。如果是生产环境，请设置为false
const debug = true

// 程序信息，置空则不显示
const info = {
	title: '愿一切过往，皆为序章。愿一切答案，都在路上。'
}

const api = {	
	login: `${host}/Base_Manage/Home/ApiSubmitLogin`,
	loginByWechat: `${host}/api/v1/login-by-wechat`,
	loginBindWechat: `${host}/api/v1/login-bind-wechat`,
	loginedBindWechat: `${host}/api/v1/login-bind-wechat`,
	logout: `${host}/api/v1/logout`	
}

module.exports = {
	api,
	debug,
	info,
}