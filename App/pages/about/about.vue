<template>
	<view class="about">
		<view class="content">
			<view class="qrcode">			
				<text class="tip">周末午后的校园，阳光明晃晃，路上没什么人。风吹过树叶，格外静谧。</text>
			</view>
			<view class="desc">
				两个女生在树荫里买水果，我随手用手机拍了下来。阳光太亮，照片都有点糊了。
			</view>
	
		</view>
		
	</view>
</template>

<style>
	page,
	view {
		display: flex;
	}

	page {
		min-height: 100%;
		background-color: #FFFFFF;
	}

	image {
		width: 360upx;
		height: 360upx;
	}

	.about {
		flex-direction: column;
		flex: 1;
	}

	.content {
		flex: 1;
		padding:30upx;
		flex-direction: column;
	}

	.qrcode {
		display: flex;
		align-items: center;
		flex-direction: column;
	}

	.qrcode .tip {
		margin-top: 20upx;
	}

	.desc {
		margin-top: 30upx;
		display: block;
	}

	.code {
		color: #e96900;
		background-color: #f8f8f8;
	}

	button {
		width: 100%;
		margin-top: 40upx;
	}

	.version {
		height: 80upx;
		line-height: 80upx;
		justify-content: center;
		color: #ccc;
	}

	.source-list {
		flex-direction: column;
	}

	.link {
		color: #007AFF;
	}
</style>
